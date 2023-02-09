export type RegistrationFormState = {
	userName: string,
	email: string,
	password: string,
	confirmPassword: string
}

export enum RegistrationFormActionType {
	SET_USER_NAME = 'SET_USER_NAME',
	SET_EMAIL = 'SET_EMAIL',
	SET_PASSWORD = 'SET_PASSWORD',
	SET_CONFIRM_PASSWORD = 'SET_CONFIRM_PASSWORD'
}

type setUserNameAction = {
	type: RegistrationFormActionType.SET_USER_NAME,
	payload: string
}

type setEmailAction = {
	type: RegistrationFormActionType.SET_EMAIL,
	payload: string
}

type setPasswordAction = {
	type: RegistrationFormActionType.SET_PASSWORD,
	payload: string
}

type setConfirmPasswordAction = {
	type: RegistrationFormActionType.SET_CONFIRM_PASSWORD,
	payload: string
}

export type RegistrationFormAction =
	setUserNameAction
	| setEmailAction
	| setPasswordAction
	| setConfirmPasswordAction;
