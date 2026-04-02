import React from 'react';
function Home() {
    return (
    <div style={styles.container}>
        <h1>Home page</h1>
        <p>Welcome to our React Router demo! This is the home page.</p>
        <p>this is the home page where users land first</p>
    </div>
    );
}

const styles = {
    container: {
        padding: '20px',
        textAlign: 'center',
        background: '#f8f9fa',
    }
};

export default Home;