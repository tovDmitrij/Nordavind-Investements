import React, { useState } from 'react';


const UpdateDictionaryForm = ({ dictionary, onSubmit }) => {
  const [name, setName] = useState(dictionary.name);
  const [description, setDescription] = useState(dictionary.description);

  const handleSubmit = (event) => {
    event.preventDefault();
    onSubmit({ ...dictionary, name, description });
  };

  return (
    <form onSubmit={handleSubmit} className='bg-slate-300'>
      <label>
        Name:
        <input type="text" value={name} onChange={(event) => setName(event.target.value)} />
      </label>
      <br />
      <label>
        Description:
        <textarea value={description} onChange={(event) => setDescription(event.target.value)} />
      </label>
      <br />
      <button type="submit">Update Entry</button>
    </form>
  );
};


export default UpdateDictionaryForm;