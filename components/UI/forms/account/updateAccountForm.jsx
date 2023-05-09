import React, { useState } from 'react';

const UpdateAccountForm = ({ account, onSubmit }) => {
  const [accountNumber, setAccountNumber] = useState(account.accountNumber);
  const [accountName, setAccountName] = useState(account.accountName);

  const handleSubmit = (event) => {
    event.preventDefault();
    onSubmit({ ...account, accountNumber, accountName });
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Account Number:
        <select value={accountNumber} onChange={(event) => setAccountNumber(event.target.value)}>
          <option value="1">1</option>
          <option value="2">2</option>
          <option value="3">3</option>
        </select>
      </label>
      <br />
      <label>
        Account Name:
        <input type="text" value={accountName} onChange={(event) => setAccountName(event.target.value)} />
      </label>
      <br />
      <button type="submit">Update Account</button>
    </form>
  );
};

export default UpdateAccountForm;
