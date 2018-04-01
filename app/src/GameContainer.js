import React, { Component } from 'react';
import { PropTypes } from 'prop-types';

export const GameContainer = ({ title, setFullscreen }) => (
	<div className="webgl-content" style={{marginTop: 250}}>
		<div id="gameContainer" style={{width: 960, height: 600}}></div>
		<div className="footer">
			<div className="webgl-logo"></div>
			<div className="fullscreen" onClick={setFullscreen}></div>
			<div className="title">{title}</div>
		</div>
	</div>
);

GameContainer.propTypes = {
	setFullscreen: PropTypes.func.isRequired,
	title: PropTypes.string
};
