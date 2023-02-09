import axios from 'axios';

const $API = axios.create({
	baseURL: 'http://localhost:5240/api/',
});

export const fetchUsers = async () => await $API.get('users');

export const registration = async (data: {
	userName: string;
	email: string;
	password: string;
	confirmPassword: string;
}) => {
	try {
		return await $API.post('account/registration', data);
	} catch (e) {
		console.log(e);
	}
};
