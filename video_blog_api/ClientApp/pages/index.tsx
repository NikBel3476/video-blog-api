import type { NextPage } from 'next';
import { Badge } from 'react-bootstrap';

const Home: NextPage = () => {
	return (
		<h1>
			<span>Main page</span>
			<Badge bg="secondary">Badge</Badge>
		</h1>
	);
};

export default Home;
