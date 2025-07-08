const NavBar = () => {
    return (
        <nav className="navbar">
            <dl className="links">
                <dt className="link">
                    <a href="/">Home</a>
                </dt>
                <dt className="link">
                    <a href="/create">Create</a>
                </dt>
                <dt className="link">
                    <a href="/read">Read</a>
                </dt>
            </dl>
        </nav>
    );
}

export default NavBar;