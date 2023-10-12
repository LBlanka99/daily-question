import "./Home.css";
import {Link} from "react-router-dom";

const Home = () => {

    return (
        <div>
            <h1>Welcome to Daily Question!</h1>
            <div className="button-container">
                <Link to="/sign-up">
                    <button>Sign up</button>
                </Link>
                <Link to="/log-in">
                    <button>Log in</button>
                </Link>
            </div>

        </div>
    );
};

export default Home;