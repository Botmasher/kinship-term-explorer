import React from 'react';
import { PropTypes } from 'prop-types';

const Footer = ({ setFullscreen }) => (
	<div className="footer">
		<div>Kinship Term Explorer created April 2018 based on data from <a href="">these sources</a>.</div>
		{/*
			<div className="webgl-logo"></div>
			<div className="fullscreen" onClick={setFullscreen}></div>
			<div className="title">{title}</div>
		*/}
		<div className="fullscreen-empty" onClick={setFullscreen}>test fullscreen</div>
	</div>
);

Footer.propTypes = {
	setFullscreen: PropTypes.func
};

export default Footer;
