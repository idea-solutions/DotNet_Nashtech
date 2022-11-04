import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./App.css";
import Navbar from "./components/Navbar/Navbar";
import Home from "./pages/Home/Home";
import Login from "./pages/Login/Login";
import Logout from "./pages/Logout/Logout";
import Posts from "./pages/Posts/Posts";

const App = () => {
    const router = createBrowserRouter([
        {
            path: "/",
            element: <Navbar />,
            children: [
                {
                    index: true,
                    element: <Home />,
                },
                {
                    path: "/posts",
                    element: <Posts />,
                    children: [
                        {
                            index: true,
                            element: <Posts />,
                        },
                    ],
                },
                {
                    path: "/login",
                    element: <Login />,
                },
                {
                    path: "/logout",
                    element: <Logout />,
                },
            ],
        },
    ]);

    return <RouterProvider router={router} />;
};

export default App;
