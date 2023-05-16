﻿namespace be.Helpers
{
    public class EmailHelper
    {
        private static EmailHelper instance;
        public static EmailHelper Instance
        {
            get { if (instance == null) instance = new EmailHelper(); return EmailHelper.instance; }
            private set { EmailHelper.instance = value; }
        }
        public string Body(string text)
        {
            return "<!doctype html>\r\n" +
                "<html>\r\n\r\n" +
                "<head>\r\n    " +
                "<meta name=\"viewport\" content=\"width=device-width\" />\r\n    " +
                "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    " +
                "<title>Simple Transactional Email</title>\r\n    " +
                "<style>\r\n        " +
                "img {\r\n            " +
                "border: none;\r\n            -" +
                "ms-interpolation-mode: bicubic;\r\n            " +
                "max-width: 100%;\r\n        }\r\n        " +
                "body {\r\n            " +
                "background-color: #f6f6f6;\r\n            " +
                "font-family: sans-serif;\r\n            " +
                "-webkit-font-smoothing: antialiased;\r\n            " +
                "font-size: 14px;\r\n            " +
                "line-height: 1.4;\r\n            " +
                "margin: 0;\r\n            " +
                "padding: 0;\r\n            " +
                "-ms-text-size-adjust: 100%;\r\n            " +
                "-webkit-text-size-adjust: 100%;\r\n        }\r\n        " +
                "table {\r\n            " +
                "border-collapse: separate;\r\n            " +
                "mso-table-lspace: 0pt;\r\n            " +
                "mso-table-rspace: 0pt;\r\n            " +
                "width: 100%;\r\n        }\r\n        " +
                "table td {\r\n            " +
                "font-family: sans-serif;\r\n           " +
                " font-size: 14px;\r\n            " +
                "vertical-align: top;\r\n        }\r\n        " +
                ".body {\r\n            " +
                "background-color: #f6f6f6;\r\n            " +
                "width: 100%;\r\n        }\r\n        " +
                ".container {\r\n            " +
                "display: block;\r\n            " +
                "Margin: 0 auto !important;\r\n           " +
                " max-width: 580px;\r\n            " +
                "padding: 10px;\r\n            " +
                "width: 580px;\r\n        }\r\n        " +
                ".content {\r\n            " +
                "box-sizing: border-box;\r\n            " +
                "display: block;\r\n            " +
                "Margin: 0 auto;\r\n            " +
                "max-width: 580px;\r\n            " +
                "padding: 10px;\r\n        }\r\n        " +
                ".main {\r\n            " +
                "background: #fff;\r\n            " +
                "border-radius: 3px;\r\n            " +
                "width: 100%;\r\n        }\r\n        " +
                ".wrapper {\r\n            " +
                "box-sizing: border-box;\r\n            " +
                "padding: 20px;\r\n        }\r\n        " +
                ".footer {\r\n            " +
                "clear: both;\r\n            " +
                "padding-top: 10px;\r\n            " +
                "text-align: center;\r\n            " +
                "width: 100%;\r\n        }\r\n        " +
                ".footer td,\r\n        " +
                ".footer p,\r\n        " +
                ".footer span,\r\n        " +
                ".footer a {\r\n            " +
                "color: #999999;\r\n            " +
                "font-size: 12px;\r\n            " +
                "text-align: center;\r\n        }\r\n        " +
                "h1,h2,h3,h4 {\r\n            " +
                "color: #000000;\r\n            " +
                "font-family: sans-serif;\r\n            " +
                "font-weight: 400;\r\n            " +
                "line-height: 1.4;\r\n            " +
                "margin: 0;\r\n            " +
                "Margin-bottom: 30px;\r\n        }\r\n        " +
                "h1 {\r\n            " +
                "font-size: 35px;\r\n            " +
                "font-weight: 300;\r\n            " +
                "text-align: center;\r\n            " +
                "text-transform: capitalize;\r\n        }\r\n        " +
                "p,\r\n        ul,\r\n        ol {\r\n            " +
                "font-family: sans-serif;\r\n            font-size: 14px;\r\n            font-weight: normal;\r\n            " +
                "margin: 0;\r\n            Margin-bottom: 15px;\r\n        }\r\n        p li,\r\n        ul li,\r\n        " +
                "ol li {\r\n            list-style-position: inside;\r\n            margin-left: 5px;\r\n        }\r\n        " +
                "a {\r\n            color: #3498db;\r\n            text-decoration: underline;\r\n        }\r\n        .btn {\r\n  " +
                "          box-sizing: border-box;\r\n            width: 100%;\r\n        }\r\n        .btn>tbody>tr>td {\r\n            " +
                "padding-bottom: 15px;\r\n        }\r\n        .btn table {\r\n            width: auto;\r\n        }\r\n        " +
                ".btn table td {\r\n            background-color: #ffffff;\r\n            border-radius: 5px;\r\n            " +
                "text-align: center;\r\n        }\r\n        .btn a {\r\n            background-color: #ffffff;\r\n            " +
                "border: solid 1px #3498db;\r\n            border-radius: 5px;\r\n            box-sizing: border-box;\r\n            " +
                "color: #3498db;\r\n            cursor: pointer;\r\n            display: inline-block;\r\n            font-size: 14px;\r\n            " +
                "font-weight: bold;\r\n            margin: 0;\r\n            padding: 12px 25px;\r\n            text-decoration: none;\r\n           " +
                " text-transform: capitalize;\r\n        }\r\n        .btn-primary table td {\r\n            background-color: #3498db;\r\n       " +
                " }\r\n        .btn-primary a {\r\n            background-color: #3498db;\r\n            border-color: #3498db;\r\n           " +
                " color: #ffffff;\r\n        }\r\n        .last {\r\n            margin-bottom: 0;\r\n        }\r\n        .first {\r\n            " +
                "margin-top: 0;\r\n        }\r\n        .align-center {\r\n            text-align: center;\r\n        }\r\n        .align-right {\r\n " +
                "           text-align: right;\r\n        }\r\n        .align-left {\r\n            text-align: left;\r\n        }\r\n       " +
                " .clear {\r\n            clear: both;\r\n        }\r\n        .mt0 {\r\n            margin-top: 0;\r\n        }\r\n        .mb0 {\r\n            " +
                "margin-bottom: 0;\r\n        }\r\n        .preheader {\r\n            color: transparent;\r\n            display: none;\r\n            " +
                "height: 0;\r\n            max-height: 0;\r\n            max-width: 0;\r\n            opacity: 0;\r\n            overflow: hidden;\r\n            " +
                "mso-hide: all;\r\n            visibility: hidden;\r\n            width: 0;\r\n        }\r\n        .powered-by a {\r\n            " +
                "text-decoration: none;\r\n        }\r\n        hr {\r\n            border: 0;\r\n            border-bottom: 1px solid #f6f6f6;\r\n            " +
                "Margin: 20px 0;\r\n        }\r\n        @media only screen and (max-width: 620px) {\r\n            table[class=body] h1 {\r\n                " +
                "font-size: 28px !important;\r\n                margin-bottom: 10px !important;\r\n            }\r\n            table[class=body] p,\r\n            " +
                "table[class=body] ul,\r\n            table[class=body] ol,\r\n            table[class=body] td,\r\n            table[class=body] span,\r\n            " +
                "table[class=body] a {\r\n                font-size: 16px !important;\r\n            }\r\n            table[class=body] .wrapper,\r\n            " +
                "table[class=body] .article {\r\n                padding: 10px !important;\r\n            }\r\n            table[class=body] .content {\r\n               " +
                " padding: 0 !important;\r\n            }\r\n            table[class=body] .container {\r\n                padding: 0 !important;\r\n                width: 100% !important;\r\n            " +
                "}\r\n            table[class=body] .main {\r\n                border-left-width: 0 !important;\r\n                border-radius: 0 !important;\r\n               " +
                " border-right-width: 0 !important;\r\n            }\r\n            table[class=body] .btn table {\r\n                width: 100% !important;\r\n            }\r\n            " +
                "table[class=body] .btn a {\r\n                width: 100% !important;\r\n            }\r\n            table[class=body] .img-responsive {\r\n                " +
                "height: auto !important;\r\n                max-width: 100% !important;\r\n                width: auto !important;\r\n            }\r\n        }\r\n        " +
                "@media all {\r\n            .ExternalClass {\r\n                width: 100%;\r\n            }\r\n            .ExternalClass,\r\n            .ExternalClass p,\r\n            " +
                ".ExternalClass span,\r\n            .ExternalClass font,\r\n            .ExternalClass td,\r\n            .ExternalClass div {\r\n                line-height: 100%;\r\n            }\r\n            " +
                ".apple-link a {\r\n                color: inherit !important;\r\n                font-family: inherit !important;\r\n                font-size: inherit !important;\r\n                " +
                "font-weight: inherit !important;\r\n                line-height: inherit !important;\r\n                text-decoration: none !important;\r\n            }\r\n            " +
                ".btn-primary table td:hover {\r\n                background-color: #34495e !important;\r\n            }\r\n            .btn-primary a:hover {\r\n                " +
                "background-color: #34495e !important;\r\n                border-color: #34495e !important;\r\n            }\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"\">\r\n    " +
                "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"body\">\r\n        <tr>\r\n            <td>&nbsp;</td>\r\n            <td class=\"container\">\r\n                " +
                "<div class=\"content\">\r\n                    <span class=\"preheader\"></span>\r\n                    <table class=\"main\">\r\n                        <tr>\r\n                           " +
                " <td class=\"wrapper\">\r\n                                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                       " +
                " <td>\r\n                                            <h1>Xác nhận email của bạn</h1>\r\n                                            <h2>Thêm 1 bước nữa để hoàn thành</h2>\r\n                                            " +
                "<p>Gửi bạn,<br>\r\n                                                Để tiếp tục đăng ký của bạn với Ký Túc Xá, vui lòng sử dụng mã xác thực sau: " + text + "<br>\r\n                                                Trân trọng.</p>\r\n                                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"btn btn-primary\">\r\n                                                <tbody>\r\n                                                    <tr>\r\n                                                        <td align=\"left\">\r\n                                                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td> <a href=\"http://htmlemail.io\" target=\"_blank\">Xác nhận Email</a> </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                </tbody>\r\n                                            </table>\r\n                                            <p>Nếu bạn nhận được email này do nhầm lẫn, chỉ cần xóa nó. Bạn sẽ không được đăng ký nếu không nhấp vào liên kết xác nhận ở trên.</p>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                </div>\r\n            </td>\r\n            <td>&nbsp;</td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>";
        }

        public string BodyReset(string text)
        {
            return "<!doctype html>\r\n" +
                "<html>\r\n\r\n" +
                "<head>\r\n    " +
                "<meta name=\"viewport\" content=\"width=device-width\" />\r\n    " +
                "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    " +
                "<title>Simple Transactional Email</title>\r\n    " +
                "<style>\r\n        " +
                "img {\r\n            " +
                "border: none;\r\n            -" +
                "ms-interpolation-mode: bicubic;\r\n            " +
                "max-width: 100%;\r\n        }\r\n        " +
                "body {\r\n            " +
                "background-color: #f6f6f6;\r\n            " +
                "font-family: sans-serif;\r\n            " +
                "-webkit-font-smoothing: antialiased;\r\n            " +
                "font-size: 14px;\r\n            " +
                "line-height: 1.4;\r\n            " +
                "margin: 0;\r\n            " +
                "padding: 0;\r\n            " +
                "-ms-text-size-adjust: 100%;\r\n            " +
                "-webkit-text-size-adjust: 100%;\r\n        }\r\n        " +
                "table {\r\n            " +
                "border-collapse: separate;\r\n            " +
                "mso-table-lspace: 0pt;\r\n            " +
                "mso-table-rspace: 0pt;\r\n            " +
                "width: 100%;\r\n        }\r\n        " +
                "table td {\r\n            " +
                "font-family: sans-serif;\r\n           " +
                " font-size: 14px;\r\n            " +
                "vertical-align: top;\r\n        }\r\n        " +
                ".body {\r\n            " +
                "background-color: #f6f6f6;\r\n            " +
                "width: 100%;\r\n        }\r\n        " +
                ".container {\r\n            " +
                "display: block;\r\n            " +
                "Margin: 0 auto !important;\r\n           " +
                " max-width: 580px;\r\n            " +
                "padding: 10px;\r\n            " +
                "width: 580px;\r\n        }\r\n        " +
                ".content {\r\n            " +
                "box-sizing: border-box;\r\n            " +
                "display: block;\r\n            " +
                "Margin: 0 auto;\r\n            " +
                "max-width: 580px;\r\n            " +
                "padding: 10px;\r\n        }\r\n        " +
                ".main {\r\n            " +
                "background: #fff;\r\n            " +
                "border-radius: 3px;\r\n            " +
                "width: 100%;\r\n        }\r\n        " +
                ".wrapper {\r\n            " +
                "box-sizing: border-box;\r\n            " +
                "padding: 20px;\r\n        }\r\n        " +
                ".footer {\r\n            " +
                "clear: both;\r\n            " +
                "padding-top: 10px;\r\n            " +
                "text-align: center;\r\n            " +
                "width: 100%;\r\n        }\r\n        " +
                ".footer td,\r\n        " +
                ".footer p,\r\n        " +
                ".footer span,\r\n        " +
                ".footer a {\r\n            " +
                "color: #999999;\r\n            " +
                "font-size: 12px;\r\n            " +
                "text-align: center;\r\n        }\r\n        " +
                "h1,h2,h3,h4 {\r\n            " +
                "color: #000000;\r\n            " +
                "font-family: sans-serif;\r\n            " +
                "font-weight: 400;\r\n            " +
                "line-height: 1.4;\r\n            " +
                "margin: 0;\r\n            " +
                "Margin-bottom: 30px;\r\n        }\r\n        " +
                "h1 {\r\n            " +
                "font-size: 35px;\r\n            " +
                "font-weight: 300;\r\n            " +
                "text-align: center;\r\n            " +
                "text-transform: capitalize;\r\n        }\r\n        " +
                "p,\r\n        ul,\r\n        ol {\r\n            " +
                "font-family: sans-serif;\r\n            font-size: 14px;\r\n            font-weight: normal;\r\n            " +
                "margin: 0;\r\n            Margin-bottom: 15px;\r\n        }\r\n        p li,\r\n        ul li,\r\n        " +
                "ol li {\r\n            list-style-position: inside;\r\n            margin-left: 5px;\r\n        }\r\n        " +
                "a {\r\n            color: #3498db;\r\n            text-decoration: underline;\r\n        }\r\n        .btn {\r\n  " +
                "          box-sizing: border-box;\r\n            width: 100%;\r\n        }\r\n        .btn>tbody>tr>td {\r\n            " +
                "padding-bottom: 15px;\r\n        }\r\n        .btn table {\r\n            width: auto;\r\n        }\r\n        " +
                ".btn table td {\r\n            background-color: #ffffff;\r\n            border-radius: 5px;\r\n            " +
                "text-align: center;\r\n        }\r\n        .btn a {\r\n            background-color: #ffffff;\r\n            " +
                "border: solid 1px #3498db;\r\n            border-radius: 5px;\r\n            box-sizing: border-box;\r\n            " +
                "color: #3498db;\r\n            cursor: pointer;\r\n            display: inline-block;\r\n            font-size: 14px;\r\n            " +
                "font-weight: bold;\r\n            margin: 0;\r\n            padding: 12px 25px;\r\n            text-decoration: none;\r\n           " +
                " text-transform: capitalize;\r\n        }\r\n        .btn-primary table td {\r\n            background-color: #3498db;\r\n       " +
                " }\r\n        .btn-primary a {\r\n            background-color: #3498db;\r\n            border-color: #3498db;\r\n           " +
                " color: #ffffff;\r\n        }\r\n        .last {\r\n            margin-bottom: 0;\r\n        }\r\n        .first {\r\n            " +
                "margin-top: 0;\r\n        }\r\n        .align-center {\r\n            text-align: center;\r\n        }\r\n        .align-right {\r\n " +
                "           text-align: right;\r\n        }\r\n        .align-left {\r\n            text-align: left;\r\n        }\r\n       " +
                " .clear {\r\n            clear: both;\r\n        }\r\n        .mt0 {\r\n            margin-top: 0;\r\n        }\r\n        .mb0 {\r\n            " +
                "margin-bottom: 0;\r\n        }\r\n        .preheader {\r\n            color: transparent;\r\n            display: none;\r\n            " +
                "height: 0;\r\n            max-height: 0;\r\n            max-width: 0;\r\n            opacity: 0;\r\n            overflow: hidden;\r\n            " +
                "mso-hide: all;\r\n            visibility: hidden;\r\n            width: 0;\r\n        }\r\n        .powered-by a {\r\n            " +
                "text-decoration: none;\r\n        }\r\n        hr {\r\n            border: 0;\r\n            border-bottom: 1px solid #f6f6f6;\r\n            " +
                "Margin: 20px 0;\r\n        }\r\n        @media only screen and (max-width: 620px) {\r\n            table[class=body] h1 {\r\n                " +
                "font-size: 28px !important;\r\n                margin-bottom: 10px !important;\r\n            }\r\n            table[class=body] p,\r\n            " +
                "table[class=body] ul,\r\n            table[class=body] ol,\r\n            table[class=body] td,\r\n            table[class=body] span,\r\n            " +
                "table[class=body] a {\r\n                font-size: 16px !important;\r\n            }\r\n            table[class=body] .wrapper,\r\n            " +
                "table[class=body] .article {\r\n                padding: 10px !important;\r\n            }\r\n            table[class=body] .content {\r\n               " +
                " padding: 0 !important;\r\n            }\r\n            table[class=body] .container {\r\n                padding: 0 !important;\r\n                width: 100% !important;\r\n            " +
                "}\r\n            table[class=body] .main {\r\n                border-left-width: 0 !important;\r\n                border-radius: 0 !important;\r\n               " +
                " border-right-width: 0 !important;\r\n            }\r\n            table[class=body] .btn table {\r\n                width: 100% !important;\r\n            }\r\n            " +
                "table[class=body] .btn a {\r\n                width: 100% !important;\r\n            }\r\n            table[class=body] .img-responsive {\r\n                " +
                "height: auto !important;\r\n                max-width: 100% !important;\r\n                width: auto !important;\r\n            }\r\n        }\r\n        " +
                "@media all {\r\n            .ExternalClass {\r\n                width: 100%;\r\n            }\r\n            .ExternalClass,\r\n            .ExternalClass p,\r\n            " +
                ".ExternalClass span,\r\n            .ExternalClass font,\r\n            .ExternalClass td,\r\n            .ExternalClass div {\r\n                line-height: 100%;\r\n            }\r\n            " +
                ".apple-link a {\r\n                color: inherit !important;\r\n                font-family: inherit !important;\r\n                font-size: inherit !important;\r\n                " +
                "font-weight: inherit !important;\r\n                line-height: inherit !important;\r\n                text-decoration: none !important;\r\n            }\r\n            " +
                ".btn-primary table td:hover {\r\n                background-color: #34495e !important;\r\n            }\r\n            .btn-primary a:hover {\r\n                " +
                "background-color: #34495e !important;\r\n                border-color: #34495e !important;\r\n            }\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"\">\r\n    " +
                "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"body\">\r\n        <tr>\r\n            <td>&nbsp;</td>\r\n            <td class=\"container\">\r\n                " +
                "<div class=\"content\">\r\n                    <span class=\"preheader\"></span>\r\n                    <table class=\"main\">\r\n                        <tr>\r\n                           " +
                " <td class=\"wrapper\">\r\n                                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                       " +
                " <td>\r\n                                            <h1>Reset password</h1>\r\n                                           \r\n                                            " +
                "<p>Gửi bạn,<br>\r\n                                                Sử dụng mã sau để đăng nhập: " + text + "<br>\r\n                                                Trân trọng.</p>\r\n                                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"btn btn-primary\">\r\n                                                <tbody>\r\n                                                    <tr>\r\n                                                        <td align=\"left\">\r\n                                                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td> <a href=\"http://htmlemail.io\" target=\"_blank\">Xác nhận Email</a> </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                </tbody>\r\n                                            </table>\r\n                                            <p>Nếu bạn nhận được email này do nhầm lẫn, chỉ cần xóa nó. Bạn sẽ không được đăng ký nếu không nhấp vào liên kết xác nhận ở trên.</p>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                </div>\r\n            </td>\r\n            <td>&nbsp;</td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>";
        }

    }
}
