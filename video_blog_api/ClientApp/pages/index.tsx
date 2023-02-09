import type { NextPage } from 'next';
import { Badge } from 'react-bootstrap';
import { useEffect, useState } from 'react';

const Home: NextPage = () => {
	const [data, setData] = useState('');

	useEffect(() => {
		fetch('/api/Account/getData').then((res) => {
			res.text().then((data) => {
				setData(data);
			});
		});
	}, []);

	return (
		<h1>
			<span>Main page</span>
			<span>{data}</span>
			<Badge bg="secondary">Badge</Badge>
		</h1>
	);
};

export default Home;
