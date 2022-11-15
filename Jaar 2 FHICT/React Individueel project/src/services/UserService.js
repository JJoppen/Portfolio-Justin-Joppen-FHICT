import axios from "axios";

const USER_API_BASE_URL = "http://localhost:8080/api/v1/user"
class UserService{

    getUsers(){
        return axios.get(USER_API_BASE_URL+"s")
    }
    getUserById(UserID){
        return axios.get(USER_API_BASE_URL +UserID)
    }
    postUsers(User){
        console.log(User+"InService")
        return axios.post(USER_API_BASE_URL, User)
    }
    putUsers(User){
        return axios.put(USER_API_BASE_URL,User)
    }
    deleteUser(Userid){
        return axios.delete(USER_API_BASE_URL,Userid)
    }
}

export default new UserService()