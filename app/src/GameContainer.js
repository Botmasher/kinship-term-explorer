import React, { Component } from 'react';
import { PropTypes } from 'prop-types';

export const GameContainer = ({ title, setFullscreen }) => (
	<div className="webgl-content">
		<div id="gameContainer"></div>
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
