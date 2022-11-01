import { useMemo, useState } from "react";
import Checkbox from "./Checkbox";
import Input from "./Input";
import './RegisterForm.css';
import Select from "./Select";

// Validations
const required = (value) => {
  if (value === '' || value === undefined || value === null) {
    return 'This field is required!';
  }
  return '';
}

const minLength = (value, length) => {
  if (value.length < length) {
    return `This field has at least ${length} character(s)`;
  }
  return '';
}

const pattern = (value, regex, message) => {
  if (!regex.test(value)) {
    return message;
  }
  return '';
}

const compare = (value, compareValue, message) => {
  if (value !== compareValue) {
    return message;
  }
  return '';
}

// Get errors
const getUserNameError = (value) => {
  return( 
    required(value) || 
    minLength(value, 4) || 
    pattern(value, /^[A-Za-z0-9_]*$/, "Only allow A-Z, a-z, 0-9!"));
}

const getEmailError = (value) => {
  return (
    required(value) ||
    pattern(value, /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/, "Invalid email address!")
  );
}

const getPasswordError = (value) => {
  return( 
    required(value) || 
    minLength(value, 8));
}

const getRetypePasswordError = (value, compareValue) => {
  return( 
    required(value) || 
    minLength(value, 8)) ||
    compare(value, compareValue, 'This field must be equal to Password!');
}

const getReadAgreementError = (value) => {
  return required(value);
}

const RegisterForm = () => {
  const genders = [
    { id: 'gender-male', name: 'Male', value: 'male' },
    { id: 'gender-female', name: 'Female', value: 'female' }
  ]

  const emptyUser = {
    userName: '',
    email: '',
    gender: '',
    password: '',
    retypePassword: '',
    readAgreement: false
  }

  const [user, setUser] = useState(emptyUser);  

  const userNameError = useMemo(() => {
    return getUserNameError(user.userName);
  }, [user.userName]);

  const emailError = useMemo(() => {
    return getEmailError(user.email);
  }, [user.email]);

  const passwordError = useMemo(() => {
    return getPasswordError(user.password);
  }, [user.password]);

  const retypePasswordError = useMemo(() => {
    return getRetypePasswordError(user.retypePassword, user.password);
  }, [user.password, user.retypePassword]);

  const readAgreementError = useMemo(() => {
    return getReadAgreementError(user.readAgreement);
  }, [user.readAgreement]);

  const handleOnChange = (event) => {
    setUser({...user, [event.target.name] : event.target.value});
  }

  return (
    <div className="register-form">
      <h1>Rookies ReactJS Day 4 - Register Form</h1>
      <form>
        <Input 
          label='Username' 
          name='userName'
          value={user.userName}
          onChange={handleOnChange}
          error={userNameError}/>
        <Input 
          label='Email' 
          name='email'
          value={user.email}
          onChange={handleOnChange}
          error={emailError}/>
        <Select
          label='Gender'
          name='gender'
          value={user.gender}
          onChange={handleOnChange}
          options={genders}/>
        <Input 
          label='Password' 
          name='password'
          value={user.password}
          onChange={handleOnChange}
          error={passwordError}
          type='password'/>
        <Input 
          label='Retype Password' 
          name='retypePassword'
          value={user.retypePassword}
          onChange={handleOnChange}
          error={retypePasswordError}
          type='password'/>
        <Checkbox 
          label='I have read agreement' 
          name='readAgreement'
          value={user.readAgreement}
          onChange={handleOnChange}
          error={readAgreementError}/>
        <button>Submit</button>
      </form>
    </div>
  )
}

export default RegisterForm;