import axios from "axios";
import react, { useState } from "react"


const CreateComment = (postId) => {
    const [comment, setComment] = useState();
    const [Success, setSuccess] = useState(false);
    const [errMsg, setErrMsg] = useState('');


    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post()
            setSuccess(true);
        } catch (err) {
            if (!err?.response) {
                setErrMsg("No server response");
                console.log(err);
            } else if (err.response?.status === 400) {
                setErrMsg("Missing data")
            } else if (err.response?.status === 403) {
                setErrMsg('Unauthorized');
            } else {
                setErrMsg('comment failed');
            }
        }
    }

    return (
            <div>
                    <form>
                        <div>
                            <textarea onChange={(e)=>setComment(e.target.value)} className="float-end w-100" placeholder="write comment"></textarea>
                        </div>
                        <div >
                            <button type="submit" className="btn btn-outline-success btn-sm float-end w-25">post comment</button>
                        </div>
                    </form>
                </div>

    )
}
export default CreateComment