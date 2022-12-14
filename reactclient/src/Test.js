import React, { Component } from 'react';
import Cookies from 'js-cookie';

export class Test extends Component {

    constructor(props) {
        super(props);
        this.state = { token: "", currentAnswers: [], question: "", currentQuestion: 0, idTest: 0, questions: [], mark: 0, isEnd: false };

        this.getQuestions = this.getQuestions.bind(this);
        this.NextQuestion = this.NextQuestion.bind(this);
        this.handleOptionChange = this.handleOptionChange.bind(this);
        this.CalculateMark = this.CalculateMark.bind(this);
        this.BackToTests = this.BackToTests.bind(this);
    }

    componentDidMount() {
        this.getQuestions();
    }

    async getQuestions() {
        var url = window.location.href;
        var id = url.substring(url.lastIndexOf('/') + 1);
        this.setState({idTest: id})
        if (Cookies.get('JWT') != null) {
            const JWTtoken = Cookies.get('JWT');
            const tokenObj = JSON.parse(JWTtoken);
            const token = tokenObj.token;
            this.setState({ token: token });
            console.log(this.state.idTest)
            const url = "https://localhost:7033/question/" + id;

            const requestOptions = {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': "Bearer " + token
                }
            };

            const response = await fetch(url, requestOptions);

            if (!response.ok) {

                // alert("wrong data");
            }
            else {
                const questions_string = await response.text();
                const questions = JSON.parse(questions_string)

                if (questions.length == 0){
                    window.location.href = "/";
                }

                this.setState({ questions: questions, question: questions[0], currentAnswers: questions[0].answers, currentResult: "", resultAnswers: [] })
                console.log(this.state.questions);
                console.log(this.state.questions.length);
                console.log(this.state.questions[this.state.currentQuestion]);
                console.log(this.state.questions[this.state.currentQuestion].content);
                console.log(this.state.currentAnswers);
            }
        }
    }

    NextQuestion() {
        let number = this.state.currentQuestion + 1
        if (number < this.state.questions.length) {
            this.setState({
                currentAnswers: this.state.questions[number].answers,
                question: this.state.questions[number]
            })
        }
        if (number <= this.state.questions.length) {
            let results = this.state.resultAnswers;
            results.push(this.state.currentResult);
            this.setState({ resultAnswers: results, currentResult: "" })
            if (number == this.state.questions.length) {
                this.CalculateMark();
            }
        }
        this.setState({ currentQuestion: number })
        console.log(this.state.resultAnswers);
    }

    async CalculateMark() {
        const url = "https://localhost:7033/mark/" + this.state.idTest;
        let answers = this.state.resultAnswers;

        answers.forEach((element, index) => {
            answers[index] = String(element);
          });
        console.log(answers)
        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': "Bearer " + this.state.token
            },
            body: JSON.stringify(answers)
        };

        const response = await fetch(url, requestOptions);

            if (!response.ok) {

                // alert("wrong data");
            }
            else {
                const mark = await response.text();
                this.setState({isEnd: true })
                alert("Your mark is: " + mark)
            }
    }

    BackToTests() {
        window.location.href = "/";
    }

    handleOptionChange(changeEvent) {
        this.setState({ currentResult: changeEvent.target.value })
    }

    render() {
        const listItems = this.state.currentAnswers.map((answer) =>
            <li>{answer}</li>
        );
        return (
            <div>
                Home page.
                <div className='question'>
                    {this.state.question.content}
                </div>
                <form>
                    {this.state.currentAnswers.map((answer, i) =>
                        <div className="radio">
                            <label>
                                <input type="radio" value={i} name="abc" ref={'ref_' + i} value={answer} onChange={this.handleOptionChange} checked={this.state.currentResult == answer ? true : false} />
                                <div>{answer}</div>

                            </label>
                        </div>
                    )}

                </form>
                <button onClick={this.state.isEnd ? this.BackToTests : this.NextQuestion}>{this.state.isEnd ? "Back" : "Next"}</button>
            </div>
        )
    }
}