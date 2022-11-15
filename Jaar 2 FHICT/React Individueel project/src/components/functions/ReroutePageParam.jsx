import * as React from 'react'
import { useNavigate } from 'react-router-dom'

function ReroutePage(RouteURL){
    const navigation = useNavigate();   

    return(
        <button className="btn btn-primary float-right" onClick={()=> navigation(RouteURL.RouteURL + RouteURL.id)}>{RouteURL.buttonData}</button>
    );
}

export default ReroutePage;
