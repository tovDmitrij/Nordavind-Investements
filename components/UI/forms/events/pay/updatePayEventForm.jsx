import React, { useState } from 'react';

const UpdatePayEventForm = ({ payEvent, onSubmit }) => {
  const [date, setDate] = useState(payEvent.date);
  const [amount, setAmount] = useState(payEvent.amount);
  const [invoice, setInvoice] = useState(payEvent.invoice);

  const handleSubmit = (event) => {
    event.preventDefault();
    onSubmit({ ...payEvent, date, amount, invoice });
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
      <button type="submit">Update Pay Event</button>
    </form>
  );
};

export default UpdatePayEventForm;
