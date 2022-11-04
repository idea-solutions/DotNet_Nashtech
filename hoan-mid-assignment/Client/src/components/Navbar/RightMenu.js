import React from "react";
import { Menu, Grid } from "antd";
import { Link } from "react-router-dom";

const { useBreakpoint } = Grid;

const RightMenu = () => {
    const { md } = useBreakpoint();

    const items = [
        {
            label: <Link to="/login">Login</Link>,
            key: "login",
        },
        {
            label: <Link to="/logout">Logout</Link>,
            key: "logout",
        },
    ];
    return <Menu mode={md ? "horizontal" : "inline"} items={items} />;
};

export default RightMenu;
