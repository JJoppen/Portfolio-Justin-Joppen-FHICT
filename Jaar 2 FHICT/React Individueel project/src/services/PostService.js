import axios from "axios";

const POST_API_BASE_URL = "http://localhost:8080/api/v1/Post"
class PostService{

    getposts(forumID){
        return axios.get(POST_API_BASE_URL+"s",forumID)
    }
    getpost(postID){
        return axios.get(POST_API_BASE_URL,postID)
    }
    postUsers(Post){

        return axios.post(POST_API_BASE_URL,Post)
    }
    putUsers(Post){
        return axios.put(POST_API_BASE_URL,Post)
    }
    deleteUser(PostID){
        return axios.delete(POST_API_BASE_URL,PostID)
    }
}

export default new PostService()