import React from "react";
import { Menu, Grid } from "antd";
import { Link } from "react-router-dom";
const { useBreakpoint } = Grid;

const LeftMenu = () => {
    const { md } = useBreakpoint();
    const items = [
        {
            label: <Link to={"/"}>Home</Link>,
            key: "home",
        },
        {
            label: <Link to={"/posts"}>Posts</Link>,
            key: "posts",
        },
        {
            label: <Link to={"/profile"}>Profile</Link>,
            key: "profile",
        },
    ];
    return (
        <Menu
            defaultSelectedKeys="home"
            mode={md ? "horizontal" : "inline"}
            items={items}
        />
    );
};

export default LeftMenu;
