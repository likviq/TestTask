import './App.css';
import { Home } from './Home';
import { Test } from './Test';
import { Login } from './Login';
import { Navigation } from './Navigation'

import { BrowserRouter, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <div>
        <h3>some text</h3>
        <Navigation/>

        <Routes>
          <Route exact path='/' element={<Home />}/>
          <Route path='/test/:id' element={<Test />}/>
          <Route path='/login' element={<Login />}/>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
