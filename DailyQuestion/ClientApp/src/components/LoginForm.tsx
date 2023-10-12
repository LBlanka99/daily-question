import "./LoginForm.css";
import React, {useState} from "react";

const LoginForm = () => {
    const [error, setError] = useState("");

    async function handleLogin(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const form = new FormData(e.target as HTMLFormElement);
        const entries = [...form.entries()];

        const credentials = entries.reduce((acc: any, entry) => {
            const [k, v] = entry;
            acc[k] = v;
            return acc;
        }, {});

        const apiAddress = "http://localhost:5194/api/v1/users/log-in";

        const init: RequestInit = {
            method: "POST",
            headers: new Headers([["content-type", "application/json"]]),
            body: JSON.stringify(credentials),
        };

        const response = await fetch(apiAddress, init);
        if (response.ok) {
            //navigate to profile page
        } else {
            const errorText = await response.text();
            setError(errorText);
        }
    }


    return (
        <div className="login-container">
            <h2>Login</h2>
            {error && <div className="error-message">{error}</div>}
            <form onSubmit={handleLogin}>
                <div className="form-group">
                    <label htmlFor="email">E-mail</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        placeholder="Enter your e-mail address"
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input
                        type="password"
                        id="password"
                        name="password"
                        placeholder="Enter your password"
                        required
                    />
                </div>
                <button type="submit">Login</button>
            </form>
        </div>
    );
};

export default LoginForm;