import React, { Component } from 'react';
import Cookies from 'js-cookie';

export class Home extends Component {

    constructor(props) {
        super(props);
        //this.intervalID = 0;
        this.state = { token: "", tests: [] };

        this.getTests = this.getTests.bind(this);
        this.openTest = this.openTest.bind(this);
    }

    componentDidMount() {
        this.getTests();
    }

    async getTests() {
        if (Cookies.get('JWT') != null) {
            const JWTtoken = Cookies.get('JWT')
            const tokenObj = JSON.parse(JWTtoken);
            const token = tokenObj.token
            this.setState({ token: token });

            const url = "https://localhost:7033/tests";

            const requestOptions = {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': "Bearer " + token
                }
            };

            const response = await fetch(url, requestOptions)

            if (!response.ok) {
                window.location.href = "/login";
            }
            else {

                const tests_result = await response.text();
                const tests = JSON.parse(tests_result)
                this.setState({ tests: tests })
                console.log(this.state.tests);

            }
        }
    }

    async openTest(idTest, description) {
        console.log(description)
        if (window.confirm(description)) {
            window.location.href = "/test/" + idTest;
        }
    }

    render() {
        const tests = this.state.tests
        return (
            <div>
                Home page.
                <div>
                    <ul>
                        {tests.map(test =>

                            <div key={test.idTest}>
                                <div>{test.title}</div>
                                <button onClick={this.openTest.bind(this, test.idTest, test.description)}>
                                    Start
                                </button>
                            </div>

                        )}
                    </ul>
                </div>
            </div>
        )
    }
}