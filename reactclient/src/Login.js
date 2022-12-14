import React, { Component } from 'react';
import Cookies from 'js-cookie';
import { useNavigate } from 'react-router-dom';

export class Login extends Component {

    constructor(props) {
        super(props);

        this.state = { email: '', password: '' };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    async handleSubmit(event) {
        event.preventDefault();

        var { uname, pass } = document.forms[0];
        const url = "https://localhost:7033/token";

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username: uname.value, password: pass.value })
        };

        const response = await fetch(url, requestOptions)
        if (!response.ok) {

            // alert("wrong data");
        }
        else {

            const token = await response.text();

            Cookies.set('JWT', token, { path: '/' });

            window.location.href = "/";
        }
    };

    render() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <div className="input-container">
                        <label>Username </label>
                        <input type="text" name="uname" required />
                    </div>
                    <div className="input-container">
                        <label>Password </label>
                        <input type="password" name="pass" required />
                    </div>
                    <div className="button-container">
                        <input type="submit" />
                    </div>
                </form>
            </div>
        )
    }
}