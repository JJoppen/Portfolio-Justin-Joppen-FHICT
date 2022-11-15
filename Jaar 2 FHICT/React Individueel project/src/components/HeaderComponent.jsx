import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import ReroutePageNoParam from './functions/ReroutePageNoParam'
import SearchForum from './functions/forumFunctions/SearchForum';

const HeaderComponent = () => {
    let navigate = useNavigate();


    return (
        <div>
            <header>
                <nav id='header-component-loaded' className="navbar navbar-expand-md navbar-dark bg-dark ">
                    <div onClick={() => navigate('')} className='float-start'><a className="navbar-brand">Sociable</a> </div>
                    {/* searchbar */}
                    <SearchForum/>
                    <div className='float-end ms-auto'>
                        <ReroutePageNoParam Id="chatroom-button" CSS="btn btn-primary me-2" RouteURL='/chat' buttonData="Chat" />
                        <ReroutePageNoParam Id="user-register-button" CSS="btn btn-primary me-2" RouteURL='/CreateAccount' buttonData="Registreren" />
                        <ReroutePageNoParam Id="user-login-button" CSS="btn btn-primary me-2" RouteURL="/Login" buttonData="Inloggen" />
                    </div>
                </nav>
            </header>
        </div>
    );

}

export default HeaderComponent;