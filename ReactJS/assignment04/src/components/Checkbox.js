import './Checkbox.css';

function Checkbox(props) {
  const { label, name, value, onChange, error, ...otherProps } = props;

  return (
    <div className='input-checkbox'>
      <label>        
        <input
          type='checkbox'
          value={value}
          onChange={onChange}
          name={name}
          {...otherProps} />
        <span>{label}</span>
        {error && <span style={{ color: 'red' }}>{error}</span>}
      </label>
    </div>
  );
}

export default Checkbox;