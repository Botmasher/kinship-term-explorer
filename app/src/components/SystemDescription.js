import React from 'react';
import PropTypes from 'prop-types';

const SystemDescription = ({currentSystemId, currentLanguage, currentDescription}) => (
	<div key={currentSystemId} className="system-description-anim">
		<p>
			<em>example language: </em>
			{currentSystemId !== "global"
				?	<a href={`https://en.wikipedia.org/wiki/${currentLanguage}_language`} target="_blank">
						<span className="system-language-label">{currentLanguage}</span>
					</a>
				: <span>(none)</span>
			}
			&nbsp;&nbsp;&nbsp;&nbsp;
			<em>system: </em>
			<a href={currentSystemId === "inuit"
				? `https://en.wikipedia.org/wiki/lineal_kinship`
				: currentSystemId === "global"
					?	`http://era.anthropology.ac.uk/Kinship/prologTerm5.html`
					: `https://en.wikipedia.org/wiki/${currentSystemId}_kinship`
			} target="_blank">
				{currentSystemId !== "global"
					? <span className="system-language-label">{currentSystemId} kinship</span>
					: <span>basic kin types</span>
				}
			</a>
		</p>
		<p>{currentDescription}</p>
	</div>
);

SystemDescription.propTypes = {
	currentSystemId: PropTypes.string.isRequired,
	currentLanguage: PropTypes.string.isRequired,
	currentDescription: PropTypes.string.isRequired
};

export default SystemDescription;
