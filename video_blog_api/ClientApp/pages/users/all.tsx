import { fetchUsers } from '../../lib/http';
import { Card } from 'react-bootstrap';
import { NextPage } from 'next';

// TODO: Add types
const UsersList: NextPage<{ users: any; error: any }> = ({ users, error }) => {
	if (error) {
		return (
			<div>
				<p>{error}</p>
			</div>
		);
	}

	return users.map((user) => (
		<Card key={user.Id}>
			<Card.Body>
				<Card.Title>{user.name}</Card.Title>
				<Card.Subtitle>{user.login}</Card.Subtitle>
			</Card.Body>
		</Card>
	));
};

export async function getServerSideProps() {
	try {
		const allUsersRequest = await fetchUsers();
		return {
			props: {
				users: allUsersRequest.data,
				error: null,
			},
		};
	} catch (e) {
		console.error(e);
		return {
			props: {
				users: [],
				error: e.message,
			},
		};
	}
}

export default UsersList;
