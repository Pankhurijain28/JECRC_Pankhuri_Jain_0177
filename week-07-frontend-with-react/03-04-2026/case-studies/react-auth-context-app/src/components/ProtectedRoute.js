import React from "react";
import {useAuth} from "../Context/authContext";

function ProtectedRoute({children}){
    const {isAuthenticated, loading} = useAuth();
    if(loading){
        return<p>Loading...</p>;

    }
    if(isAuthenticated){
        return <p> You must be logged in to view this Page.</p>
    }
    return children;
}

export default ProtectedRoute;