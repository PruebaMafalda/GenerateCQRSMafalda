using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GeneratePostman;

public class GenerateJsonCollectionContent : GenerateBase
{
    public string GetGenerateJsonCollectionContent(GenerateParams model)
    {
        /*
        {
          "info": {
            "_postman_id": "c149427b-2217-40f6-aecc-78c80d1563a1",
            "name": "New Collection",
            "schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json",
            "_exporter_id": "42391869",
            "_collection_link": "https://mafalda-2471.postman.co/workspace/MafaldaTeam~3b5c442f-0e54-481e-92c6-eaa1f6c2b0f2/collection/42391869-c149427b-2217-40f6-aecc-78c80d1563a1?action=share&source=collection_link&creator=42391869"
          },
          "item": [
            {
              "name": "Courses Copy",
              "item": [
                {
                  "name": "CourseCreate",
                  "request": {
                    "auth": {
                      "type": "bearer",
                      "bearer": [
                        {
                          "key": "token",
                          "value": "{{TokenBearer}}",
                          "type": "string"
                        }
                      ]
                    },
                    "method": "POST",
                    "header": [
                      {
                        "key": "X-Api-Key",
                        "value": "e5fe10d2-972e-4fc8-904a-da3d34a9aa93",
                        "type": "text",
                        "disabled": true
                      }
                    ],
                    "body": {
                      "mode": "raw",
                      "raw": "{\r\n    \"name\": \"Curso de programacion 1 con Angular 17\",\r\n    \"startDate\": \"2024-10-20T00:00:00Z\",\r\n    \"endDate\": \"2024-11-25T00:00:00Z\",\r\n    \"closeDate\": \"2024-10-25T00:00:00Z\",\r\n    \"description\": \"Curso recomendado\",\r\n    \"objectives\": \"Aprendere a programacion\",\r\n    \"content\": \"se aprenderan varios lenguajes de programación\",\r\n    \"methodology\": \"virtual\",\r\n    \"isActive\": true,\r\n    \"isCanceled\": true,\r\n    \"planId\": 1\r\n}",
                      "options": {
                        "raw": {
                          "language": "json"
                        }
                      }
                    },
                    "url": {
                      "raw": "{{AtencionEstudiante}}/api/v1/courses",
                      "host": [
                        "{{AtencionEstudiante}}"
                      ],
                      "path": [
                        "api",
                        "v1",
                        "courses"
                      ]
                    }
                  },
                  "response": []
                },
                {
                  "name": "CourseUpdate",
                  "request": {
                    "auth": {
                      "type": "bearer",
                      "bearer": [
                        {
                          "key": "token",
                          "value": "{{TokenBearer}}",
                          "type": "string"
                        }
                      ]
                    },
                    "method": "PUT",
                    "header": [
                      {
                        "key": "X-Api-Key",
                        "value": "e5fe10d2-972e-4fc8-904a-da3d34a9aa93",
                        "type": "text",
                        "disabled": true
                      }
                    ],
                    "body": {
                      "mode": "raw",
                      "raw": "{\r\n    \"name\": \"Curso Avanzado de Programacion\",\r\n    \"startDate\": \"2024-10-20T00:00:00Z\",\r\n    \"endDate\": \"2024-11-25T00:00:00Z\",\r\n    \"closeDate\": \"2024-10-25T00:00:00Z\",\r\n    \"description\": \"Curso recomendado\",\r\n    \"objectives\": \"Aprendere a programacion\",\r\n    \"content\": \"se aprenderan varios lenguajes de programación\",\r\n    \"methodology\": \"virtual\",\r\n    \"isActive\": true,\r\n    \"isCanceled\": true,\r\n    \"planId\": 1\r\n}",
                      "options": {
                        "raw": {
                          "language": "json"
                        }
                      }
                    },
                    "url": {
                      "raw": "{{FrontalesCepal}}/api/v1/courses/6",
                      "host": [
                        "{{FrontalesCepal}}"
                      ],
                      "path": [
                        "api",
                        "v1",
                        "courses",
                        "6"
                      ]
                    }
                  },
                  "response": []
                },
                {
                  "name": "CourseGetById",
                  "protocolProfileBehavior": {
                    "disableBodyPruning": true
                  },
                  "request": {
                    "auth": {
                      "type": "bearer",
                      "bearer": [
                        {
                          "key": "token",
                          "value": "{{TokenBearer}}",
                          "type": "string"
                        }
                      ]
                    },
                    "method": "GET",
                    "header": [
                      {
                        "key": "X-Api-Key",
                        "value": "e5fe10d2-972e-4fc8-904a-da3d34a9aa93",
                        "type": "text",
                        "disabled": true
                      }
                    ],
                    "body": {
                      "mode": "raw",
                      "raw": "",
                      "options": {
                        "raw": {
                          "language": "json"
                        }
                      }
                    },
                    "url": {
                      "raw": "http://localhost:5000/api/v1/courses/2",
                      "protocol": "http",
                      "host": [
                        "localhost"
                      ],
                      "port": "5000",
                      "path": [
                        "api",
                        "v1",
                        "courses",
                        "2"
                      ]
                    }
                  },
                  "response": []
                },
                {
                  "name": "CourseGetByFilter",
                  "event": [
                    {
                      "listen": "prerequest",
                      "script": {
                        "exec": [
                          ""
                        ],
                        "type": "text/javascript",
                        "packages": {}
                      }
                    }
                  ],
                  "request": {
                    "auth": {
                      "type": "bearer",
                      "bearer": [
                        {
                          "key": "token",
                          "value": "{{TokenBearer}}",
                          "type": "string"
                        }
                      ]
                    },
                    "method": "POST",
                    "header": [
                      {
                        "key": "X-Api-Key",
                        "value": "e5fe10d2-972e-4fc8-904a-da3d34a9aa93",
                        "type": "text",
                        "disabled": true
                      }
                    ],
                    "body": {
                      "mode": "raw",
                      "raw": "{\r\n    \"PlanId\":0\r\n}",
                      "options": {
                        "raw": {
                          "language": "json"
                        }
                      }
                    },
                    "url": {
                      "raw": "{{FrontalesCepal}}/api/v1/courses/filter",
                      "host": [
                        "{{FrontalesCepal}}"
                      ],
                      "path": [
                        "api",
                        "v1",
                        "courses",
                        "filter"
                      ]
                    }
                  },
                  "response": []
                },
                {
                  "name": "CourseDelete",
                  "request": {
                    "auth": {
                      "type": "bearer",
                      "bearer": [
                        {
                          "key": "token",
                          "value": "{{TokenBearer}}",
                          "type": "string"
                        }
                      ]
                    },
                    "method": "DELETE",
                    "header": [
                      {
                        "key": "X-Api-Key",
                        "value": "e5fe10d2-972e-4fc8-904a-da3d34a9aa93",
                        "type": "text"
                      }
                    ],
                    "body": {
                      "mode": "raw",
                      "raw": "",
                      "options": {
                        "raw": {
                          "language": "json"
                        }
                      }
                    },
                    "url": {
                      "raw": "{{FrontalesCepal}}/api/v1/courses/0",
                      "host": [
                        "{{FrontalesCepal}}"
                      ],
                      "path": [
                        "api",
                        "v1",
                        "courses",
                        "0"
                      ]
                    }
                  },
                  "response": []
                }
              ],
              "event": [
                {
                  "listen": "prerequest",
                  "script": {
                    "type": "text/javascript",
                    "packages": {},
                    "exec": [
                      ""
                    ]
                  }
                },
                {
                  "listen": "test",
                  "script": {
                    "type": "text/javascript",
                    "packages": {},
                    "exec": [
                      ""
                    ]
                  }
                }
              ]
            }
          ]
        }


        */

        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"{{{_singlelb}";
        content += $"{_space}\"info\": {{ {_singlelb}";
        content += $"{_space}{_space}\"_postman_id\": \"{Guid.NewGuid()}\", {_singlelb}";
        content += $"{_space}{_space}\"name\": \"{model.PluralName} Collection\", {_singlelb}";
        content += $"{_space}{_space}\"schema\": \"https://schema.getpostman.com/json/collection/v2.1.0/collection.json\", {_singlelb}";
        content += $"{_space}{_space}\"_exporter_id\": \"{Guid.NewGuid()}\", {_singlelb}";
        content += $"{_space}{_space}\"_collection_link\": \"https://mafalda-2471.postman.co/workspace/MafaldaTeam~3b5c442f-0e54-481e-92c6-eaa1f6c2b0f2/collection/{Guid.NewGuid()}-{Guid.NewGuid()}-{Guid.NewGuid()}-{Guid.NewGuid()}-{Guid.NewGuid()}?action=share&source=collection_link&creator={Guid.NewGuid()}\"{_singlelb}";
        content += $"{_space}}}, {_singlelb}";
        content += $"{_space}\"item\": [ {_singlelb}";
        content += $"{_space}{_space}{{ {_singlelb}";
        content += $"{_space}{_space}{_space}\"name\": \"{model.PluralName}\", {_singlelb}";
        content += $"{_space}{_space}{_space}\"item\": [ {_singlelb}";
        var rawContent = string.Empty;
        var numberRequest = 0;
        if (model.CrudTypes.Contains(CrudType.Create))
        {
            content += $"{_space}{_space}{_space}{_space}{{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"name\": \"{model.SingularName}Create\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"request\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"auth\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"bearer\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"bearer\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"token\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{TokenBearer}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"string\" {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"method\": \"POST\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"header\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"X-Api-Key\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{ApiKey}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"text\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"disabled\": true {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"body\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"mode\": \"raw\", {_singlelb}";
            rawContent = GetGenerateRawRequest(model);
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"{rawContent}\",{_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"options\": {{\"raw\": {{\"language\": \"json\"}}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"url\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"{{{{{PathProject.BaseUrl}}}}}/api/v1/{model.PluralName.ToLower()}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"host\": [ \"{{{{{PathProject.BaseUrl}}}}}\" ], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"path\": [ \"api\", \"v1\", \"{model.PluralName.ToLower()}\" ] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"response\": [] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}}} {_singlelb}";
            numberRequest++;
        }

        if (model.CrudTypes.Contains(CrudType.Update))
        {
            if (numberRequest > 0) content += $"{_space}{_space}{_space}{_space}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"name\": \"{model.SingularName}Update\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"request\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"auth\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"bearer\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"bearer\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"token\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{TokenBearer}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_singlelb} {_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"string\" {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"method\": \"PUT\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"header\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"X-Api-Key\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{ApiKey}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"text\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"disabled\": true {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"body\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"mode\": \"raw\", {_singlelb}";
            rawContent = GetGenerateRawRequest(model);
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"{rawContent}\",{_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"options\": {{\"raw\": {{\"language\": \"json\"}}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"url\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"{{{{{PathProject.BaseUrl}}}}}/api/v1/{model.PluralName.ToLower()}/1\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"host\": [ \"{{{{{PathProject.BaseUrl}}}}}\" ], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"path\": [ \"api\", \"v1\", \"{model.PluralName.ToLower()}\", \"1\" ] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"response\": [] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}}} {_singlelb}";
            numberRequest++;
        }

        if (model.CrudTypes.Contains(CrudType.GetById))
        {
            if (numberRequest > 0) content += $"{_space}{_space}{_space}{_space}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"name\": \"{model.SingularName}GetById\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"protocolProfileBehavior\": {{\"disableBodyPruning\": true}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"request\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"auth\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"bearer\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"bearer\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"token\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{TokenBearer}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"string\" {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"method\": \"GET\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"header\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"X-Api-Key\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{ApiKey}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"text\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"disabled\": true {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"body\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"mode\": \"raw\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"\",{_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"options\": {{\"raw\": {{\"language\": \"json\"}}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"url\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"{{{{{PathProject.BaseUrl}}}}}/api/v1/{model.PluralName.ToLower()}/1\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"host\": [ \"{{{{{PathProject.BaseUrl}}}}}\" ], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"path\": [ \"api\", \"v1\", \"{model.PluralName.ToLower()}\", \"1\" ] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"response\": [] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}}} {_singlelb}";
            numberRequest++;
        }
        if (model.CrudTypes.Contains(CrudType.GetByFilter))
        {
            if (numberRequest > 0) content += $"{_space}{_space}{_space}{_space}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"name\": \"{model.SingularName}GetByFilter\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"event\": [ {{\"listen\":\"prerequest\",\"script\":{{\"exec\":[\"\"],\"type\":\"text/javascript\",\"packages\":{{}}}}}}, {{\"listen\":\"test\",\"script\":{{\"exec\":[\"\"],\"type\":\"text/javascript\",\"packages\":{{}}}}}} ], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"request\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"auth\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"bearer\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"bearer\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"token\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{TokenBearer}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"string\" {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"method\": \"POST\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"header\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"X-Api-Key\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{ApiKey}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"text\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"disabled\": true {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"body\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"mode\": \"raw\", {_singlelb}";
            rawContent = GetGenerateRawRequest(model,true);
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"{rawContent}\",{_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"options\": {{\"raw\": {{\"language\": \"json\"}}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"url\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"{{{{{PathProject.BaseUrl}}}}}/api/v1/{model.PluralName.ToLower()}/filter\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"host\": [ \"{{{{{PathProject.BaseUrl}}}}}\" ], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"path\": [ \"api\", \"v1\", \"{model.PluralName.ToLower()}\", \"filter\" ] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"response\": [] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}}} {_singlelb}";
            numberRequest++;
        }
        if (model.CrudTypes.Contains(CrudType.Delete))
        {
            if (numberRequest > 0) content += $"{_space}{_space}{_space}{_space}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"name\": \"{model.SingularName}Delete\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"request\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"auth\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"bearer\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"bearer\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"token\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{TokenBearer}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"string\" {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}{_space}}}{_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}]{_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}},{_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"method\": \"DELETE\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"header\": [ {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"key\": \"X-Api-Key\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"value\": \"{{{{ApiKey}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"type\": \"text\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"disabled\": true {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}\"body\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"mode\": \"raw\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"\",{_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"options\": {{\"raw\": {{\"language\": \"json\"}}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}\"url\": {{ {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"raw\": \"{{{{{PathProject.BaseUrl}}}}}/api/v1/{model.PluralName.ToLower()}/{{{{id}}}}\", {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"host\": [ \"{{{{{PathProject.BaseUrl}}}}}\" ], {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}{_space}\"path\": [ \"api\", \"v1\", \"{model.PluralName.ToLower()}\", \"{{{{id}}}}\" ] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}{_space}}} {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}{_space}}}, {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}\"response\": [] {_singlelb}";
            content += $"{_space}{_space}{_space}{_space}}} {_singlelb}";
        }

        content += $"{_space}{_space}{_space}], {_singlelb}";
        content += $"{_space}{_space}{_space}\"event\":[{{\"listen\":\"prerequest\",\"script\":{{\"type\":\"text/javascript\",\"packages\":{{}},\"exec\":[\"\"]}}}},{{\"listen\":\"test\",\"script\":{{\"type\":\"text/javascript\",\"packages\":{{}},\"exec\":[\"\"]}}}}]{_singlelb}";
        content += $"{_space}{_space}}} {_singlelb}";
        content += $"{_space}] {_singlelb}";
        content += $"}} {_singlelb}";


        return content;
    }

    private string GetGenerateRawRequest(GenerateParams model, bool isFilter = false)
    {
        var fields = model.Fields.Where(x => !x.IsPrimaryKey).ToList();
        if(isFilter)
        {
            fields = fields.Where(x => x.IsEspecification).ToList();
        }

        if (fields.Count == 0)
        {
            return "{}";
        }
        var rawContent = "{";
        var index = 0;
        foreach (var field in fields)
        {
            if (index > 0)
            {
                rawContent += ",\r\n";
            }
            else
            {
                rawContent += "\r\n";
            }
            if (IsNumberOrBoolean(field.Type))
            {
                rawContent += $"    \"{field.NameCamelCase}\": {field.TestExample}";
            }
            else
            {
                rawContent += $"    \"{field.NameCamelCase}\": \"{field.TestExample}\"";
            }
            index++;
        }
        
        rawContent += "\r\n}";
        rawContent = rawContent.Replace("\r\n", "\\r\\n");
        rawContent = rawContent.Replace("\"", "\\\"");
        rawContent = rawContent.Replace("{{", "\\{\\{");
        rawContent = rawContent.Replace("}}", "\\}\\}");
        return rawContent;
    }

    private bool IsNumberOrBoolean(FieldType type)
    {
        return type == FieldType.Int || type == FieldType.BigInt || type == FieldType.Decimal || type == FieldType.Double || type == FieldType.Bool;
    }
}