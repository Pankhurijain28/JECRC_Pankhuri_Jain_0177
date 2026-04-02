import React from 'react';
function Contact() {
    return (
    <div style={styles.container}>
        <h1>Contact pages</h1>
        <p>You can reach us at:</p>
        <p> Email: support@example.com</p>
        <p> Phone: +1 234 567 890</p>
    </div>
    );
}

const styles = {
    container: {
        padding: '20px',
        textAlign: 'center',
        background: '#d4edda',
    }
};

export default Contact;