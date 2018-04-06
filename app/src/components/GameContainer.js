import React from 'react';
import { PropTypes } from 'prop-types';

const GameContainer = ({ title, setFullscreen }) => (
	<div className="webgl-content">
		<div id="gameContainer"></div>
		<div className="footer">
			<div>Kinship Term Explorer created April 2018 based on data from <a href="">these sources</a>.</div>
			{/*
				<div className="webgl-logo"></div>
				<div className="fullscreen" onClick={setFullscreen}></div>
				<div className="title">{title}</div>
			*/}
		</div>
	</div>
);

GameContainer.propTypes = {
	//setFullscreen: PropTypes.func.isRequired,
	title: PropTypes.string
};

export default GameContainer;
