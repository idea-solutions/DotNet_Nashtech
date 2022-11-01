function Input(props) {
    const { label, name, value, onChange, error, ...otherProps } = props;
  
    return (
      <div className='input-field'>
        <label>
          <span>{label}</span>
          <input
            value={value}
            onChange={onChange}
            name={name}
            {...otherProps} />
          {error && <span style={{ color: 'red' }}>{error}</span>}
        </label>
      </div>
    );
  }
  
  export default Input;