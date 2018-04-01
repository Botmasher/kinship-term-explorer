import React, { Component } from 'react';
import { PropTypes } from 'prop-types';

export const GameMenu = ({ systems, system, language, handleUpdateTreeLabels }) => (
	<div>
		{Object.keys(systems).map(sysName => (
			<div>
				<h2>{sysName} Kinship System</h2>
				<ul key={sysName}>
					{systems[sysName].map(langName => (
						<li key={langName}>
							{langName === language && (
								<span><strong>{language}</strong></span>
							)}
							{langName !== language && (
								<a onClick={() => handleUpdateTreeLabels(sysName, langName)}>{langName} terms</a>
							)}
						</li>
					))}
				</ul>
			</div>
		))}
	</div>
);

GameMenu.propTypes = {
	systems: PropTypes.object.isRequired,
	system: PropTypes.string.isRequired,
	language: PropTypes.string.isRequired,
	handleUpdateTreeLabels: PropTypes.func.isRequired
};
