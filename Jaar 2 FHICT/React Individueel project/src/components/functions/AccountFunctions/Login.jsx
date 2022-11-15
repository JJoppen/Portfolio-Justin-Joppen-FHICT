import { useRef, useState, useEffect, useContext } from "react";
import AuthContext from "../../context/AuthProvider";


import axios from "axios";
const LOGIN_URL = "http://localhost:8080/api/v1/users/signin"

const Login =()=>{
    const { setAuth } = useContext(AuthContext);
    const userRef =useRef();
    const errRef = useRef();

    const [userName, setUserName] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [Success, setSuccess] = useState(false)


    useEffect(()=>{
        userRef.current.focus();
    },[])

    useEffect(()=>{
        setErrMsg('');
    },[userName,pwd])

    const handleSubmit = async () =>{

        try{
            const response = await axios.post(LOGIN_URL +"?username="+userName+"&password="+pwd);
            console.log(JSON.stringify(response?.data))
            const accessToken = response?.data;
            setAuth({userName,pwd,accessToken});
            setUserName('');
            setPwd('');
            setSuccess(true);
        }

        catch(err){
            if(!err?.response){
                setErrMsg("No server response");
                console.log(err);
            }else if(err.response?.status === 400){
                setErrMsg("Missing username or password")
            }else if(err.response?.status === 401){
                setErrMsg('Unauthorized');
            }else{
                setErrMsg('Login failed');
            }
            errRef.current.focus();
        }
    }
    
    return(
        <>
        {
            Success?(
                <section>
                    <h1 id="login-correct">You are logged in!</h1>
                    <br/>
                    <p>
                        <a href="#">Go to homepage.</a>
                    </p>
                </section>
            ) : (
                <section>
                    <p ref={errRef} className={errMsg ? "errmsg":"offscreen"} aria-live="assertive">{errMsg}</p>
                    <h1>Sign In</h1>
                    <form onSubmit={handleSubmit}>
                        <label id="username-label" htmlFor="username">Username:</label>
                        <input
                            type='text'
                            id="username"
                            ref={userRef}
                            autoComplete="off"
                            onChange={(e)=>setUserName(e.target.value)}
                            value={userName}
                            required
                            />
                        <label htmlFor="password">Password:</label>
                        <input
                            type="password"
                            id="password"
                            onChange={(e)=> setPwd(e.target.value)}
                            value={pwd}
                            required
                        />
                        <button id="login">sign in</button>
                    </form>
                    <p>
                        need an account?<br/>
                        <span className="line">
                            {/*router setting */}
                            <a href="#">sign up</a>
                        </span>
                    </p>
                        
                    
                </section>
            )
        }
        </>
    )
    

}
export default Login