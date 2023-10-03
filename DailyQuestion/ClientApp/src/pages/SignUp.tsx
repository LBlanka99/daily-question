import "./SignUp.css";
import React, {useState} from "react";
import { Link, useNavigate } from "react-router-dom";

const SignUp = () => {
    const [data, setData]: any = useState(null);

    const navigate = useNavigate();

    async function sendRegisterInfo(e: React.FormEvent) {
        e.preventDefault();
        // verify data
        // send data to a server

    }

    return (
    <div className="signup-container">
        <form className="signup-form" onSubmit={sendRegisterInfo}>
            <h2>Sign Up</h2>
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
                    name="password-again"
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