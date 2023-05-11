import React, { useState } from 'react';

const AddAccountForm = ({ onSubmit }) => {
  const [accountNumber, setAccountNumber] = useState('');
  const [accountName, setAccountName] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    onSubmit({ accountNumber, accountName });
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Account Number:
        <select value={accountNumber} onChange={(event) => setAccountNumber(event.target.value)}>
          <option value="1">1</option>
          <option value="2">2</option>
          <option value="3">3</option>
          {/*ХЗ херня какая то */}
        </select>
      </label>
      <br />
      <label>
        Account Name:
        <input type="text" value={accountName} onChange={(event) => setAccountName(event.target.value)} />
      </label>
      <br />
      <button type="submit">Add Account</button>
    </form>
  );
};

export default AddAccountForm;
