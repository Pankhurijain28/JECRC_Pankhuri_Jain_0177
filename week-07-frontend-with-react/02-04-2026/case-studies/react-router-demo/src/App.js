import {BrowserRouter, Routes, Route, NavLink} from 'react-router-dom';
import Home from './pages/home';
import About from './pages/about';
import Contact from './pages/contact';

function App() {
    return (
    <BrowserRouter>
        <nav style={styles.nav}>
            <NavLink to="/" style={styles.link} activeStyle={styles.activeLink} end>Home</NavLink>
            <NavLink to="/about" style={styles.link} activeStyle={styles.activeLink}>About</NavLink>
            <NavLink to="/contact" style={styles.link} activeStyle={styles.activeLink}>Contact</NavLink>
        </nav>

        <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/about" element={<About />} />
            <Route path="/contact" element={<Contact />} />
        </Routes>
    </BrowserRouter>
    );
}

const styles = {
    nav: {
        display: 'flex',
        justifyContent: 'center',
        padding: '10px',
        background: '#343a40',
        gap : '20px',
    },
    link: ({isActive}) => ({
        color: isActive ? '#fff' : '#adb5bd',
        fontWeight: isActive ? 'bold' : 'normal',
        textDecoration: 'none',
    })
};

export default App;