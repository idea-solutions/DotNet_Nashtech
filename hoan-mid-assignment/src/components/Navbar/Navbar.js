import React, { useState } from "react";
import LeftMenu from "./LeftMenu";
import RightMenu from "./RightMenu";
import { Drawer, Button } from "antd";
import { Link, Outlet } from "react-router-dom";

const Navbar = () => {
    const [visible, setVisible] = useState(false);

    const showDrawer = () => {
        setVisible(true);
    };

    const onClose = () => {
        setVisible(false);
    };
    return (
        <>
            <nav className="menuBar">
                <span className="logo">
                    <Link to="/">logo</Link>
                </span>
                <div className="menuCon">
                    <div className="leftMenu">
                        <LeftMenu />
                    </div>
                    <div className="rightMenu">
                        <RightMenu />
                    </div>
                    <Button
                        className="barsMenu"
                        type="primary"
                        onClick={showDrawer}
                    >
                        <span className="barsBtn"></span>
                    </Button>
                    <Drawer
                        title="Menu"
                        placement="right"
                        closable={false}
                        onClose={onClose}
                        open={visible}
                    >
                        <LeftMenu />
                        <RightMenu />
                    </Drawer>
                </div>
            </nav>
            <Outlet />
        </>
    );
};

export default Navbar;
