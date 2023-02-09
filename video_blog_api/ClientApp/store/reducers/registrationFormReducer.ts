import { RegistrationFormActionType, RegistrationFormState } from '../types/registrationForm';

export const initialState: RegistrationFormState = {
	userName: '',
	email: '',
	password: '',
	confirmPassword: ''
}

export const registrationFormReducer = (
	state: RegistrationFormState,
	action: { type: RegistrationFormActionType, payload: {} }
) => {
	switch (action.type) {
		case RegistrationFormActionType.SET_USER_NAME:
			return { ...state, userName: action.payload };
		case RegistrationFormActionType.SET_EMAIL:
			return { ...state, email: action.payload };
		case RegistrationFormActionType.SET_PASSWORD:
			return { ...state, password: action.payload };
		case RegistrationFormActionType.SET_CONFIRM_PASSWORD:
			return { ...state, confirmPassword: action.payload };
		default:
			return state;
	}
}
