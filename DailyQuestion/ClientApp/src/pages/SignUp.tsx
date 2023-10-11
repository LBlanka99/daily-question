import "./SignUp.css";
import React, {FormEvent, useState} from "react";
import { Link, useNavigate } from "react-router-dom";
import {Console} from "inspector";

const SignUp = () => {
    const [error, setError]: any = useState(null);

    const navigate = useNavigate();

    async function sendRegisterInfo(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        setError(null);
        // verify data
        const form = new FormData(e.target as HTMLFormElement);
        const entries : [string, FormDataEntryValue][] = [...form.entries()];

        const user = entries.reduce((acc: any, entry) => {
            const [k, v] = entry;
            acc[k] = v;
            return acc;
        }, {});


        if (user.password !== user.passwordAgain) {
            setError("The two passwords don't match!");
            return;
        }

        // send data to server
        const apiAddress = "http://localhost:5194/api/v1/users";
        
        const body = JSON.stringify({
            UserName: user.username,
            Email: user.email,
            Password: user.password,            
        });

        const init: RequestInit = {
            method: "POST",
            headers: new Headers([["content-type", "application/json"]]),
            body: body,
        };

        const response = await fetch(apiAddress, init);
        if (response.ok) {
            navigate("/first-login");
        } else {
            const text = await response.text();
            setError(text);
        }



    }

    return (
    <div className="signup-container">
        <form className="signup-form" onSubmit={sendRegisterInfo}>
            <h2>Sign Up</h2>
            {error &&
                <span className="error">{error}</span>
            }
            <div className="form-group">
                <label htmlFor="username">Username</label>
                <input
                    type="text"
                    id="username"
                    name="username"
                    placeholder="username"
                    required
                />
            </div>
            <div className="form-group">
                <label htmlFor="email">Email</label>
                <input
                    type="email"
                    id="email"
                    name="email"
                    placeholder="e-mail"
                    required
                />
            </div>
            <div className="form-group">
                <label htmlFor="password">Password</label>
                <input
                    type="password"
                    id="password"
                    name="password"
                    placeholder="password"
                    required
                />
            </div>
            <div className="form-group">
                <label htmlFor="password-again">Password Again</label>
                <input
                    type="password"
                    id="password-again"
                    name="passwordAgain"
                    placeholder="password again"
                    required
                />
            </div>
            <button type="submit">Sign Up</button>
        </form>
    </div>
    );
};

export default SignUp;