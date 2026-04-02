import React from 'react';

function About() {
    return (
    <div style={styles.container}>
        <h1>About pages</h1>
        <p>This is the about page of our React Router concepts</p>
        <p> it includes navigation, routing and component rendering.</p>
    </div>
    );
}

const styles = {
    container: {
        padding: '20px',
        textAlign: 'center',
        background: '#f0f0f0',
    }
};

export default About;