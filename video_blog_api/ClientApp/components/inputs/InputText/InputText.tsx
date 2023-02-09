import { ChangeEventHandler, FC } from 'react';
import styles from './InputText.module.css';

type InputTextProps = {
	required?: boolean;
	placeholder?: string;
	value?: string;
	onChange?: ChangeEventHandler<HTMLInputElement>;
};

const InputText: FC<InputTextProps> = ({
	required = false,
	placeholder = '',
	value = '',
	onChange = () => {},
}) => {
	return (
		<input
			className={styles.inputText}
			type="text"
			required={required}
			placeholder={placeholder}
			value={value}
			onChange={onChange}
		/>
	);
};

export default InputText;
