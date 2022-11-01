function Select(props) {
    const { label, name, value, options = [], onChange } = props;
  
    return (
      <div className='input-select'>
        <label>
          <span>{label}</span>
          <select name={name} value={value} onChange={onChange}>
            <option disabled value=''> -- Select an option -- </option>
            {
              options.map(item => 
                <option key={item.id} value={item.value}>
                  {item.name}
                </option>
              )
            }
          </select>
        </label>
      </div>
    );
  }
  
  export default Select;