import { ChangeEventHandler, FC, FormEventHandler, useReducer, useState } from 'react';
import { LockClosedIcon } from '@heroicons/react/20/solid';
import styles from './RegistrationForm.module.css';
import { registration } from '../../../lib/http';
import {
	initialState,
	registrationFormReducer,
} from '../../../store/reducers/registrationFormReducer';

type RegistrationFormProps = {};

const RegistrationForm: FC<RegistrationFormProps> = () => {
	// TODO: remake with useReducer
	const [userName, setUserName] = useState<string>('');
	const [email, setEmail] = useState<string>('');
	const [password, setPassword] = useState<string>('');
	const [confirmPassword, setConfirmPassword] = useState<string>('');

	const [formState, dispatch] = useReducer(registrationFormReducer, initialState);

	const handleUserNameChange: ChangeEventHandler<HTMLInputElement> = (event) => {
		setUserName(event.target.value);
	};

	const handleEmailChange: ChangeEventHandler<HTMLInputElement> = (event) => {
		setEmail(event.target.value);
	};

	const handlePasswordChange: ChangeEventHandler<HTMLInputElement> = (event) => {
		setPassword(event.target.value);
	};

	const handlePasswordConfirmChange: ChangeEventHandler<HTMLInputElement> = (event) => {
		setConfirmPassword(event.target.value);
	};

	const handleSubmit: FormEventHandler<HTMLFormElement> = async (event) => {
		event.preventDefault();
		const result = await registration({ userName, email, password, confirmPassword });
		console.log(result);
	};

	return (
		<>
			{/*
        This example requires updating your template:

        ```
        <html class="h-full bg-gray-50">
        <body class="h-full">
        ```
      */}
			<div className="flex min-h-full items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
				<div className="w-full max-w-md space-y-8">
					<div>
						<img
							className="mx-auto h-12 w-auto"
							src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=600"
							alt="Your Company"
						/>
						<h2 className="mt-6 text-center text-3xl font-bold tracking-tight text-gray-900">
							Sign in to your account
						</h2>
						<p className="mt-2 text-center text-sm text-gray-600">
							Or{' '}
							<a href="#" className="font-medium text-indigo-600 hover:text-indigo-500">
								start your 14-day free trial
							</a>
						</p>
					</div>
					<form className="mt-8 space-y-6" onSubmit={handleSubmit}>
						<input type="hidden" name="remember" defaultValue="true" />
						<div className="-space-y-px rounded-md shadow-sm">
							<div>
								<label htmlFor="user-name" className="sr-only">
									Email address
								</label>
								<input
									id="user-name"
									name="user-name"
									type="text"
									autoComplete="text"
									required
									className="relative block w-full appearance-none rounded-none rounded-t-md border border-gray-300 px-3 py-2 text-gray-900 placeholder-gray-500 focus:z-10 focus:border-indigo-500 focus:outline-none focus:ring-indigo-500 sm:text-sm"
									placeholder="Email address"
									value={userName}
									onChange={handleUserNameChange}
								/>
							</div>
							<div>
								<label htmlFor="email-address" className="sr-only">
									Email address
								</label>
								<input
									id="email-address"
									name="email"
									type="email"
									autoComplete="email"
									required
									className="relative block w-full appearance-none rounded-none border border-gray-300 px-3 py-2 text-gray-900 placeholder-gray-500 focus:z-10 focus:border-indigo-500 focus:outline-none focus:ring-indigo-500 sm:text-sm"
									placeholder="Email address"
									value={email}
									onChange={handleEmailChange}
								/>
							</div>
							<div>
								<label htmlFor="password" className="sr-only">
									Password
								</label>
								<input
									id="password"
									name="password"
									type="password"
									autoComplete="current-password"
									required
									className="relative block w-full appearance-none rounded-none border border-gray-300 px-3 py-2 text-gray-900 placeholder-gray-500 focus:z-10 focus:border-indigo-500 focus:outline-none focus:ring-indigo-500 sm:text-sm"
									placeholder="Password"
									value={password}
									onChange={handlePasswordChange}
								/>
							</div>
							<div>
								<label htmlFor="password-confirm" className="sr-only">
									Password
								</label>
								<input
									id="password-confirm"
									name="password-confirm"
									type="password"
									autoComplete="current-password"
									required
									className="relative block w-full appearance-none rounded-none rounded-b-md border border-gray-300 px-3 py-2 text-gray-900 placeholder-gray-500 focus:z-10 focus:border-indigo-500 focus:outline-none focus:ring-indigo-500 sm:text-sm"
									placeholder="Password confirm"
									value={confirmPassword}
									onChange={handlePasswordConfirmChange}
								/>
							</div>
						</div>

						<div className="flex items-center justify-between">
							<div className="flex items-center">
								<input
									id="remember-me"
									name="remember-me"
									type="checkbox"
									className="h-4 w-4 rounded border-gray-300 text-indigo-600 focus:ring-indigo-500"
								/>
								<label htmlFor="remember-me" className="ml-2 block text-sm text-gray-900">
									Remember me
								</label>
							</div>

							<div className="text-sm">
								<a href="#" className="font-medium text-indigo-600 hover:text-indigo-500">
									Forgot your password?
								</a>
							</div>
						</div>

						<div>
							<button
								type="submit"
								className="group relative flex w-full justify-center rounded-md border border-transparent bg-indigo-600 py-2 px-4 text-sm font-medium text-white hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
							>
								<span className="absolute inset-y-0 left-0 flex items-center pl-3">
									<LockClosedIcon
										className="h-5 w-5 text-indigo-500 group-hover:text-indigo-400"
										aria-hidden="true"
									/>
								</span>
								Sign in
							</button>
						</div>
					</form>
				</div>
			</div>
		</>
	);
};

export default RegistrationForm;