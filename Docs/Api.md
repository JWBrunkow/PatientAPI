# Patient API

- Patient API Endpoints
  - [Create Patient](#create-patient)
    - [Create Patient Request](#create-patient-request)
    - [Create Patient Response](#create-patient-response)
  - [Get Patient](#get-patient)
    - [Get Patient Request](#get-patient-request)
    - [Get Patient Response](#get-patient-response)
  - [Update Patient](#update-patient)
    - [Update Patient Request](#update-patient-request)
    - [Update Patient Response](#update-patient-response)
  - [Delete Patient](#delete-patient)
    - [Delete Patient Request](#delete-patient-request)
    - [Delete Patient Response](#delete-patient-response)

## Create Patient

### Create Patient Request

```js
POST /Patients
```

```json
{
    "Name": "Bugs Bunny",
    "Description": "A wabbit",
    "AdmissionDateTime": "2023-12-01T09:00:00",
    "DischargeDateTime": "2023-12-02T06:00:00",
    "Symptoms": [
        "Large anvil-shaped mark on head",
        "Headache",
        "Can see in the dark"
    ],
    "Outcomes": [
        "Anvil mark gone",
        "headache gone",
        "Can still see in the dark"
    ]
}
```

### Create Patient Response

```js
201 Created
```

```yml
Location: {{host}}/Patients/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "Name": "Bugs Bunny",
    "Description": "A wabbit",
    "AdmissionDateTime": "2023-12-01T09:00:00",
    "DischargeDateTime": "2023-12-02T06:00:00",
    "Symptoms": [
        "Large anvil-shaped mark on head",
        "Headache",
        "Can see in the dark"
    ],
    "Outcomes": [
        "Anvil mark gone",
        "headache gone",
        "Can still see in the dark"
    ]
}
```

## Get Patient

### Get Patient Request

```js
GET /Patients/{{id}}
```

### Get Patient Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "Name": "Bugs Bunny",
    "Description": "A wabbit",
    "AdmissionDateTime": "2023-12-01T09:00:00",
    "DischargeDateTime": "2023-12-02T06:00:00",
    "Symptoms": [
        "Large anvil-shaped mark on head",
        "Headache",
        "Can see in the dark"
    ],
    "Outcomes": [
        "Anvil mark gone",
        "headache gone",
        "Can still see in the dark"
    ]
}
```

## Update Patient

### Update Patient Request

```js
PUT /Patients/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "Name": "Daffy Duck",
    "Description": "A Duck",
    "AdmissionDateTime": "2023-12-01T09:00:00",
    "DischargeDateTime": "2023-12-02T06:00:00",
    "Symptoms": [
        "Large anvil-shaped mark on head",
        "Headache",
        "Can see in the dark"
    ],
    "Outcomes": [
        "Anvil mark gone",
        "headache gone",
        "Can still see in the dark"
    ]
}
```

### Update Patient Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Patients/{{id}}
```

## Delete Patient

### Delete Patient Request

```js
DELETE /Patients/{{id}}
```

### Delete Patient Response

```js
204 No Content
```
