import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import './style/bootstrap.min.css';
import './style/site.css';
import { BrowserRouter as Router } from 'react-router-dom'

ReactDOM.render(
    (<Router>
        <App />
    </Router>
    ),
    document.getElementById('root'));
registerServiceWorker();
