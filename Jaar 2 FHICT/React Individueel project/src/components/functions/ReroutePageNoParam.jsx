import * as React from 'react'
import { useNavigate } from 'react-router-dom'

function ReroutePageNoParam(RouteURL){
    const navigation = useNavigate();
    return(
        <button id={RouteURL.Id} className={RouteURL.CSS} style={RouteURL.style} onClick={()=> navigation(RouteURL.RouteURL)}>{RouteURL.buttonData}</button>
        
    );
}

export default ReroutePageNoParam;