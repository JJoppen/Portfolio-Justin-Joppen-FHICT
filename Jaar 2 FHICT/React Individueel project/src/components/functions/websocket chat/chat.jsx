import React,{useState} from "react";
import SockJsClient from 'react-stomp';

const SOCKET_URL= 'http://localhost:8080/websocket'

const Chat = ()=>{
    const [message, setMessage]=useState();

    let onConnected=()=>{
        console.log("Connected")
    }

    let onMessageRecieved = (msg)=>{
        setMessage(msg.message);
    }

    return(
        <div>
            <SockJsClient
                url={SOCKET_URL}
                topics={['/topic/message']}
                onConnect={onConnected}
                onDisconnect={console.log('Disconnected')}
                onMessage={msg=>onMessageRecieved(msg)}
                debug={true}
            />
            <div>{message}</div>
        </div>
    );

}

export default Chat;