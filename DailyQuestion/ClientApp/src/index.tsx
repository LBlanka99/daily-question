import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {createBrowserRouter, RouterProvider} from "react-router-dom";
import Home from "./pages/Home";
import Footer from "./components/Footer";
import SignUp from "./pages/SignUp";
import LoginForm from "./components/LoginForm";
import FirstLogin from "./pages/FirstLogin";

const router = createBrowserRouter([
    {
        path: "/",
        element: (
            <>
                <Home/> <Footer/>
            </>
        ),
    },
    {
        path: "/sign-up",
        element: (
            <>
                <SignUp/> <Footer/>
            </>
        ),
    },
    {
        path: "/log-in",
        element: (
            <>
                <LoginForm/> <Footer/>
            </>
        )
    },
    {
        path: "/first-login",
        element: (
            <>
                <FirstLogin/> <LoginForm/> <Footer/>
            </>
        )
    }
]);

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <React.StrictMode>
    <RouterProvider router={router}/>
  </React.StrictMode>
);
