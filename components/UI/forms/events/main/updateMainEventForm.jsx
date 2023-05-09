import React, { useState } from "react";

const UpdateMainEventForm = ({ investors, accountNumbers, onSubmit }) => {
  const [date, setDate] = useState("");
  const [investor, setInvestor] = useState("");
  const [value, setValue] = useState("");
  const [accountNumber, setAccountNumber] = useState("");

  const handleSubmit = (event) => {
    event.preventDefault();
    onSubmit({ date, investor, value, accountNumber });
    setDate("");
    setInvestor("");
    setValue("");
    setAccountNumber("");
  };

  return (
    <form onSubmit={handleSubmit}>
      <label htmlFor="date">Date:</label>
      <input
        type="date"
        id="date"
        name="date"
        value={date}
        onChange={(event) => setDate(event.target.value)}
      />
      <br />

      <label htmlFor="investor">Investor:</label>
      <select
        id="investor"
        name="investor"
        value={investor}
        onChange={(event) => setInvestor(event.target.value)}
      >
        <option value="">Select an investor</option>
        {investors.map((investor) => (
          <option key={investor.id} value={investor.id}>
            {investor.name}
          </option>
        ))}
      </select>
      <br />

      <label htmlFor="value">Value:</label>
      <input
        type="number"
        id="value"
        name="value"
        value={value}
        onChange={(event) => setValue(event.target.value)}
      />
      <br />

      <label htmlFor="accountNumber">Account Number:</label>
      <select
        id="accountNumber"
        name="accountNumber"
        value={accountNumber}
        onChange={(event) => setAccountNumber(event.target.value)}
      >
        <option value="">Select an account number</option>
        {accountNumbers.map((accountNumber) => (
          <option key={accountNumber.id} value={accountNumber.id}>
            {accountNumber.number}
          </option>
        ))}
      </select>
      <br />

      <button type="submit">Add Main Event</button>
    </form>
  );
};

export default UpdateMainEventForm;
