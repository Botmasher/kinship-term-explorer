import React from 'react';
import { PropTypes } from 'prop-types';
import Footer from './Footer';

const GameContainer = ({ title, setFullscreen }) => (
	<div className="webgl-content">
		<div id="gameContainer"></div>
		<Footer setFullscreen={setFullscreen} />
	</div>
);

GameContainer.propTypes = {
	setFullscreen: PropTypes.func,
	title: PropTypes.string
};

export default GameContainer;
