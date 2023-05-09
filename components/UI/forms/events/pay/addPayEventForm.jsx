import React, { useState } from 'react';

const AddPayEventForm = ({ onSubmit }) => {
  const [date, setDate] = useState('');
  const [amount, setAmount] = useState('');
  const [invoice, setInvoice] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    onSubmit({ date, amount, invoice });
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Date:
        <input type="date" value={date} onChange={(event) => setDate(event.target.value)} />
      </label>
      <br />
      <label>
        Amount:
        <input type="number" value={amount} onChange={(event) => setAmount(event.target.value)} />
      </label>
      <br />
      <label>
        Invoice:
        <input type="text" value={invoice} onChange={(event) => setInvoice(event.target.value)} />
      </label>
      <br />
      <button type="submit">Add Pay Event</button>
    </form>
  );
};

export default AddPayEventForm;
