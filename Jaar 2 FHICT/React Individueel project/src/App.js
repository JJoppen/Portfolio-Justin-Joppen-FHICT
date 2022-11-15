import logo from './logo.svg';
import './App.css';
import HeaderComponent from './components/HeaderComponent';
import FooterComponent from './components/FooterComponent';
import { BrowserRouter as Router } from 'react-router-dom';
import { Routes, Route } from 'react-router';
import UpdateAccount from './components/functions/AccountFunctions/UpdateAccount'
import Register from './components/functions/AccountFunctions/Register';
import Login from './components/functions/AccountFunctions/Login';
import ReadPost from './components/functions/postFunctions/posts';
import ChatRoom from './components/functions/websocket chat/chatroom';
import MultiplePosts from './components/functions/postFunctions/multiplePosts';
import CreateComment from './components/functions/commentFunctions/CreateComment';
import PostComment from './components/functions/commentFunctions/postComments';
import PostWithComment from './components/functions/postFunctions/postWithComments';
import ForumWithPosts from './components/functions/forumFunctions/ForumWithPosts';
import CreatePost from './components/functions/postFunctions/createPost';

function App() {
  return (
    <div>
      <Router>
        <div>
          <HeaderComponent />
          <div className="container">
            <Routes>
              <Route path="/" element={<MultiplePosts />} />
              <Route path="/users" element={<MultiplePosts />} />
              <Route path="/Register" element={<Register />} />
              <Route path="/EditAccount/:ID" element={<UpdateAccount />} />
              <Route path="/Login" element={<Login />} />
              <Route path="/Post/:ID" element={<ReadPost/>} />
              <Route path="/chat" element={<ChatRoom />} />
              <Route path='/posts' element={<MultiplePosts />} />
              <Route path='/createComment' element={<CreateComment/>}/>
              <Route path='/postComment' element={<PostComment postId="1"/>}/>
              <Route path='/postWithComment/:ID' element={<PostWithComment/>}/>
              <Route path='/forumWithPost/:ID' element={<ForumWithPosts/>}/>
              <Route path='/createPost/:ID' element={<CreatePost/>}/>
            </Routes>
          </div>
          <div className="fixed-bottom">
          </div>
        </div>
      </Router>
    </div>
  );
}

export default App;
