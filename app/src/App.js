import React, { Component } from 'react';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);
    this.gameInstance = window.gameInstance;
  }

  handleChangeLabels (e) {
    e.preventDefault();
    this.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', e.target.dataset.value);
  }

  render() {
    console.log(this.gameInstance);
    return (
      <div className = "App">
        <div className="webgl-content" style={{marginTop: 150}}>
         <a data-value="Primary" onClick={e => this.handleChangeLabels(e)}>Primary terms</a>
          <a data-value="English" onClick={e => this.handleChangeLabels(e)}>English terms</a>
          <div id="gameContainer" style={{width: 960, height: 600}}></div>
          <div className="footer">
            <div className="webgl-logo"></div>
            <div className="fullscreen" onClick={() => this.gameInstance.SetFullscreen(1)}></div>
            <div className="title">Kinship Term Explorer</div>
          </div>
        </div>
      </div>
    );
  }
}

export default App;
